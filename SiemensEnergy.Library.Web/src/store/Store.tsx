import { configureStore } from '@reduxjs/toolkit';
import livrosReducer from './livrosSlice';
import autoresReducer from './autoresSlice';
import generosReducer from './generosSlice';

export const store = configureStore({
  reducer: {
    livros: livrosReducer,
    autores: autoresReducer,
    generos: generosReducer
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;