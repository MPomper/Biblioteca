export interface Livro {
  id: number;
  titulo: string;
  idAutor: number;
  idGenero: number;
  autor?: string;
  genero?: string;
}