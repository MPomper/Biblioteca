import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { Genero } from '../models/Genero';
import { api } from "../services/Api";

interface GenerosState {
  data: Genero[];
  selected: Genero | null;
  loading: boolean;
  errors: Record<string, string[]> | null;
}

const initialState: GenerosState = {
  data: [],
  selected: null,
  loading: false,
  errors: null,
};

export const fetchByIdGenero = createAsyncThunk('generos/fetchById',
  async (id: number, thunkAPI) => {
    try {
      const response = await api.get<Genero>(`/api/v1.0/Generos/${id}`);
      return response.data;
    } catch (err: any) {
      return thunkAPI.rejectWithValue(err.message);
    }
  }
);

export const fetchAllGeneros = createAsyncThunk('generos/fetchAll',
  async (_, thunkAPI) => {
    try {
      const response = await api.get('/api/v1.0/Generos');
      return response.data;
    } catch (err: any) {
      return thunkAPI.rejectWithValue(err.message);
    }
  }
);

export const createGenero = createAsyncThunk('generos/create',
  async (genero: Omit<Genero, 'id' | 'livros'>, thunkAPI) => {
    try {
      const response = await api.post<Genero>('/api/v1.0/Generos', genero);
      return response.data;
    } catch (err: any) {
      if (err.response?.status === 400 && err.response.data?.errors) {
        return thunkAPI.rejectWithValue(err.response.data.errors);
      }
      return thunkAPI.rejectWithValue({ general: ['Erro inesperado'] });
    }
  }
);

export const updateGenero = createAsyncThunk('generos/update',
  async ({ genero }: { genero: Genero }, thunkAPI) => {
    try {
      const response = await api.put(`/api/v1.0/Generos`, genero);
      return response.data;
    } catch (err: any) {
      if (err.response?.status === 400 && err.response.data?.errors) {
        return thunkAPI.rejectWithValue(err.response.data.errors);
      }
      return thunkAPI.rejectWithValue({ general: ['Erro inesperado'] });
    }
  }
);

export const deleteGenero = createAsyncThunk('generos/delete',
  async (id: number, thunkAPI) => {
    try {
      await api.delete(`/api/v1.0/Generos/${id}`);
      return id;
    } catch (err: any) {
      return thunkAPI.rejectWithValue(err.message);
    }
  }
);

const generosSlice = createSlice({
  name: 'generos',
  initialState,
  reducers: {
    updateSelected: (state, action) => {
      state.selected = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(fetchByIdGenero.fulfilled, (state, action) => {
        state.selected = action.payload;
      })
      //fetch todos os generos
      .addCase(fetchAllGeneros.pending, (state) => {
        state.loading = true;
        state.errors = null;
      })
      .addCase(fetchAllGeneros.fulfilled, (state, action) => {
        state.loading = false;
        state.data = action.payload;
      })
      .addCase(fetchAllGeneros.rejected, (state, action) => {
        state.loading = false;
        state.errors = { general: [action.payload as string] };
      })
      //create generos
      .addCase(createGenero.pending, (state) => {
        state.loading = true;
        state.errors = null;
      })
      .addCase(createGenero.fulfilled, (state, action) => {
        state.data.push(action.payload);
      })
      .addCase(createGenero.rejected, (state, action) => {
        state.loading = false;
        state.errors = action.payload as Record<string, string[]>;
      })
      //update genero
      .addCase(updateGenero.fulfilled, (state, action) => {
        const index = state.data.findIndex(l => l.id === action.payload.id);
        if (index !== -1) {
          state.data[index] = action.payload;
        }
      })
      .addCase(updateGenero.rejected, (state, action) => {
        state.loading = false;
        state.errors = action.payload as Record<string, string[]>;
      })
      //delete genero
      .addCase(deleteGenero.fulfilled, (state, action) => {
        state.data = state.data.filter(l => l.id !== action.payload);
      });
  },
});

export default generosSlice.reducer;
