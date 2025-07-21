import { api } from './Api';
import { Genero } from '../models/Genero';

export const generoService = {
  fetchAllGeneros: () => api.get<Genero[]>('/api/v1.0/Generos'),
  fetchGeneroById: (id: number) => api.get<Genero>(`/api/v1.0/Generos/${id}`),
  createGenero: (Genero: Omit<Genero, 'id' | 'livros'>) => api.post<Genero>('/api/v1.0/Generos', Genero),
  updateGenero: (Genero: Genero) => api.put('/api/v1.0/Generos', Genero),
  deleteGenero: (id: number) => api.delete(`/api/v1.0/Generos/${id}`),
};