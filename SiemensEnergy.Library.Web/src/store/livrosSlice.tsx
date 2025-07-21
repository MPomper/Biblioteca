import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { Livro } from '../models/Livro';
import { livroService } from '../services/livroService';

interface LivrosState {
  data: Livro[];
  selected: Livro | null;
  filtro: Livro[];
  loading: boolean;
  errors: Record<string, string[]> | null;
}

const initialState: LivrosState = {
  data: [],
  selected: null,
  filtro: [],
  loading: false,
  errors: null,
};

export const fetchLivroById = createAsyncThunk('livros/fetchById',
  async (id: number, thunkAPI) => {
    try {
      const response = await livroService.fetchLivroById(id);
      return response.data;
    } catch (err: any) {
      return thunkAPI.rejectWithValue(err.message);
    }
  }
);

export const fetchLivroByFiltro = createAsyncThunk('livros/fetchByFiltro',
  async (livro: Omit<Livro, 'id'>, thunkAPI) => {
    try {
      const response = await livroService.fetchLivroByFiltro(livro);
      return response.data;
    } catch (err: any) {
      return thunkAPI.rejectWithValue(err.message);
    }
  }
);

export const fetchAllLivros = createAsyncThunk('livros/fetchAllLivros',
  async (_, thunkAPI) => {
    try {
      const response = await livroService.fetchAllLivros();
      return response.data;
    } catch (err: any) {
      return thunkAPI.rejectWithValue(err.message);
    }
  }
);

export const createLivro = createAsyncThunk('livros/create',
  async (livro: Omit<Livro, 'id'>, thunkAPI) => {
    try {
      const response = await livroService.createLivro(livro);
      return response.data;
    } catch (err: any) {
      if (err.response?.status === 400 && err.response.data?.errors) {
        return thunkAPI.rejectWithValue(err.response.data.errors);
      }
      return thunkAPI.rejectWithValue({ general: ['Erro inesperado'] });
    }
  }
);

export const updateLivro = createAsyncThunk('livros/update',
  async ({ livro }: { livro: Livro }, thunkAPI) => {
    try {
      const response = await livroService.updateLivro(livro);
      return response.data;
    } catch (err: any) {
      if (err.response?.status === 400 && err.response.data?.errors) {
        return thunkAPI.rejectWithValue(err.response.data.errors);
      }
      return thunkAPI.rejectWithValue({ general: ['Erro inesperado'] });
    }
  }
);

export const deleteLivro = createAsyncThunk('livros/delete',
  async (id: number, thunkAPI) => {
    try {
      await livroService.deleteLivro(id);
      return id;
    } catch (err: any) {
      return thunkAPI.rejectWithValue(err.message);
    }
  }
);

const livrosSlice = createSlice({
  name: 'livros',
  initialState,
  reducers: {
    updateSelected: (state, action) => {
      state.selected = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder
      //fetch by id
      .addCase(fetchLivroById.pending, (state) => {
        state.loading = true;
        state.errors = null;
      })
      .addCase(fetchLivroById.fulfilled, (state, action) => {
        state.selected = action.payload;
      })
      .addCase(fetchLivroById.rejected, (state, action) => {
        state.loading = false;
        state.errors = { general: [action.payload as string] };
      })
      //fetch by filtro
      .addCase(fetchLivroByFiltro.pending, (state) => {
        state.loading = true;
        state.errors = null;
      })
      .addCase(fetchLivroByFiltro.fulfilled, (state, action) => {
        state.loading = false;
        state.filtro = action.payload;
      })
      .addCase(fetchLivroByFiltro.rejected, (state, action) => {
        state.loading = false;
        state.errors = { general: [action.payload as string] };
      })
      //fetch todos os livros
      .addCase(fetchAllLivros.pending, (state) => {
        state.loading = true;
        state.errors = null;
      })
      .addCase(fetchAllLivros.fulfilled, (state, action) => {
        state.loading = false;
        state.data = action.payload;
      })
      .addCase(fetchAllLivros.rejected, (state, action) => {
        state.loading = false;
        state.errors = { general: [action.payload as string] };
      })
      //create Livro
      .addCase(createLivro.pending, (state) => {
        state.loading = true;
        state.errors = null;
      })
      .addCase(createLivro.fulfilled, (state, action) => {
        state.data.push(action.payload);
      })
      .addCase(createLivro.rejected, (state, action) => {
        state.loading = false;
        state.errors = action.payload as Record<string, string[]>;
      })
      //update Livro
      .addCase(updateLivro.fulfilled, (state, action) => {
        const index = state.data.findIndex(l => l.id === action.payload.id);
        if (index !== -1) {
          state.data[index] = action.payload;
        }
      })
      .addCase(updateLivro.rejected, (state, action) => {
        state.loading = false;
        state.errors = action.payload as Record<string, string[]>;
      })
      //delete Livro
      .addCase(deleteLivro.fulfilled, (state, action) => {
        state.data = state.data.filter(l => l.id !== action.payload);
      });
  },
});

export default livrosSlice.reducer;