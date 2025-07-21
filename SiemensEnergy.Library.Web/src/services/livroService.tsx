import { api } from './Api';
import { Livro } from '../models/Livro';

export const livroService = {
  fetchAllLivros: () => api.get<Livro[]>('/api/v1.0/Livros'),
  fetchLivroById: (id: number) => api.get<Livro>(`/api/v1.0/Livros/${id}`),
  fetchLivroByFiltro: (livro: Omit<Livro, 'id'>) => api.get<Livro[]>('/api/v1.0/Livros/buscar', {
        params: livro
  }),
  createLivro: (livro: Omit<Livro, 'id'>) => api.post<Livro>('/api/v1.0/Livros', livro),
  updateLivro: (livro: Livro) => api.put('/api/v1.0/Livros', livro),
  deleteLivro: (id: number) => api.delete(`/api/v1.0/Livros/${id}`),
};