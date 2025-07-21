import { Livro } from "./Livro";

export interface Genero {
  id: number;
  descricao: string;
  livros: Array<String>;
}