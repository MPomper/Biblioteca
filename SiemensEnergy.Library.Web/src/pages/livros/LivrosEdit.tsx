import { useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { AppDispatch, RootState } from '../../store/Store';
import { fetchLivroById, updateLivro } from '../../store/livrosSlice';
import { Button, Form } from 'react-bootstrap';
import { Autor } from '../../models/Autor';
import { Genero } from '../../models/Genero';

const LivrosEdit = () => {
  const { id } = useParams();
  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();
  const { livro, autoresList, generosList, errors } = useSelector((state: RootState) => {
    return { livro: state.livros.selected, autoresList: state.autores, generosList: state.generos, errors: state.livros.errors };
  });

  useEffect(() => {
    if (id) {
      dispatch(fetchLivroById(Number(id)));
    }
  }, [dispatch, id]);

  if (!livro) return <p>Carregando...</p>;

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    dispatch(updateLivro({livro}))
      .unwrap()
      .then(() => navigate('/livros'))
      .catch(err => console.error('Erro ao atualizar:', err));
  };

  return (
    <div>
      <h1>Editar Livro</h1>
      <Form id='frmLivro' onSubmit={handleSubmit}>
        <Form.Group className="mb-2" controlId="formTitulo">
          <Form.Label>Título</Form.Label>
          <Form.Control type="text" value={livro.titulo} onChange={(e) => dispatch({ type: 'livros/updateSelected', payload: { ...livro, titulo: e.target.value } })} placeholder="Titulo do livro" />
          {errors?.IdTitulo && <p style={{ color: 'red', margin: 0 }}>{errors.IdTitulo[0]}</p>}
        </Form.Group>
        <Form.Group className="mb-2" controlId="formAutor">
          <Form.Label>Autor</Form.Label>
          <Form.Select aria-label="Default select example" value={livro.idAutor} onChange={(e) => dispatch({ type: 'livros/updateSelected', payload: { ...livro, idAutor: e.target.value } })}>
            <option>Selecione</option>
            {
              autoresList.data.map((autor: Autor) => (
                <option value={autor.id}>{autor.nome}</option>
              ))
            }
          </Form.Select>
          {errors?.Autor && <p style={{ color: 'red', margin: 0 }}>{errors.Autor[0]}</p>}
        </Form.Group>
        <Form.Group className="mb-2" controlId="formGenero">
          <Form.Label>Gênero</Form.Label>
          <Form.Select aria-label="Default select example" value={livro.idGenero} onChange={(e) => dispatch({ type: 'livros/updateSelected', payload: { ...livro, idGenero: e.target.value } })}>
            <option>Selecione</option>
            {
              generosList.data.map((genero: Genero) => (
                <option value={genero.id}>{genero.descricao}</option>
              ))
            }
          </Form.Select>
          {errors?.IdGenero && <p style={{ color: 'red', margin: 0 }}>{errors.IdGenero[0]}</p>}
        </Form.Group>
        <Button variant="primary" type="submit">
          Salvar
        </Button>
      </Form>
    </div>
  );
};

export default LivrosEdit;
