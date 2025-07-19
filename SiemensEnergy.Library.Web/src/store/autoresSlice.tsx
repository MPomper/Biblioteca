import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { Autor } from '../models/Autor';
import { api } from '../services/Api';

interface AutoresState {
  data: Autor[];
  selected: Autor | null;
  loading: boolean;
  errors: Record<string, string[]> | null;
}

const initialState: AutoresState = {
  data: [],
  selected: null,
  loading: false,
  errors: null,
};

export const fetchByIdAutor = createAsyncThunk(
  'autores/fetchById',
  async (id: number, thunkAPI) => {
    try {
      const response = await api.get<Autor>(`/api/v1.0/Autores/${id}`);
      return response.data;
    } catch (err: any) {
      return thunkAPI.rejectWithValue(err.message);
    }
  }
);

export const fetchAllAutores = createAsyncThunk(
  'autores/fetchAll',
  async (_, thunkAPI) => {
    try {
      const response = await api.get('/api/v1.0/Autores');
      return response.data;
    } catch (err: any) {
      return thunkAPI.rejectWithValue(err.message);
    }
  }
);

export const createAutor = createAsyncThunk(
  'autores/create',
  async (autor: Omit<Autor, 'id' | 'livros'>, thunkAPI) => {
    try {
      const response = await api.post<Autor>('/api/v1.0/Autores', autor);
      return response.data;
    } catch (err: any) {
      if (err.response?.status === 400 && err.response.data?.errors) {
        return thunkAPI.rejectWithValue(err.response.data.errors);
      }
      return thunkAPI.rejectWithValue({ general: ['Erro inesperado'] });
    }
  }
);

export const updateAutor = createAsyncThunk(
  'autores/update',
  async ({ autor }: { autor: Autor }, thunkAPI) => {
    try {
      const response = await api.put(`/api/v1.0/Autores`, autor);
      return response.data;
    } catch (err: any) {
      if (err.response?.status === 400 && err.response.data?.errors) {
        return thunkAPI.rejectWithValue(err.response.data.errors);
      }
      return thunkAPI.rejectWithValue({ general: ['Erro inesperado'] });
    }
  }
);

export const deleteAutor = createAsyncThunk(
  'autores/delete',
  async (id: number, thunkAPI) => {
    try {
      await api.delete(`/api/v1.0/Autores/${id}`);
      return id;
    } catch (err: any) {
      return thunkAPI.rejectWithValue(err.message);
    }
  }
);

const autoresSlice = createSlice({
  name: 'autores',
  initialState,
  reducers: {
    updateSelected: (state, action) => {
      state.selected = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(fetchByIdAutor.fulfilled, (state, action) => {
        state.selected = action.payload;
      })
      // Fetch todos os autores
      .addCase(fetchAllAutores.pending, (state) => {
        state.loading = true;
        state.errors = null;
      })
      .addCase(fetchAllAutores.fulfilled, (state, action) => {
        state.loading = false;
        state.data = action.payload;
      })
      .addCase(fetchAllAutores.rejected, (state, action) => {
        state.loading = false;
        state.errors = { general: [action.payload as string] };
      })
      // Create autores
      .addCase(createAutor.pending, (state) => {
        state.loading = true;
        state.errors = null;
      })
      .addCase(createAutor.fulfilled, (state, action) => {
        state.loading = false;
        state.data.push(action.payload);
      })
      .addCase(createAutor.rejected, (state, action) => {
        state.loading = false;
        state.errors = action.payload as Record<string, string[]>;
      })
      // Update autor
      .addCase(updateAutor.fulfilled, (state, action) => {
        const index = state.data.findIndex((l) => l.id === action.payload.id);
        if (index !== -1) {
          state.data[index] = action.payload;
        }
      })
      .addCase(updateAutor.rejected, (state, action) => {
        state.loading = false;
        state.errors = action.payload as Record<string, string[]>;
      })
      // Delete autor
      .addCase(deleteAutor.fulfilled, (state, action) => {
        state.data = state.data.filter((l) => l.id !== action.payload);
      });
  },
});

export const { updateSelected } = autoresSlice.actions;
export default autoresSlice.reducer;
