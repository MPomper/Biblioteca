import { api } from './Api';
import { Autor } from '../models/Autor';

export const autorService = {
  fetchAllAutores: () => api.get<Autor[]>('/api/v1.0/Autores'),
  fetchAutorById: (id: number) => api.get<Autor>(`/api/v1.0/Autores/${id}`),
  createAutor: (Autor: Omit<Autor, 'id' | 'livros'>) => api.post<Autor>('/api/v1.0/Autores', Autor),
  updateAutor: (Autor: Autor) => api.put('/api/v1.0/Autores', Autor),
  deleteAutor: (id: number) => api.delete(`/api/v1.0/Autores/${id}`),
};