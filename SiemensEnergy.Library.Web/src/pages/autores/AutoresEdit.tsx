import { useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { AppDispatch, RootState } from '../../store/Store';
import { fetchByIdAutor, updateAutor } from '../../store/autoresSlice';
import { Button, Form } from 'react-bootstrap';

const AutoresEdit = () => {
  const { id } = useParams();
  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();
  const autor = useSelector((state: RootState) => state.autores.selected);

  useEffect(() => {
    if (id) {
      dispatch(fetchByIdAutor(Number(id)));
    }
  }, [dispatch, id]);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!autor) return;
    dispatch(updateAutor({ autor }))
      .unwrap()
      .then(() => navigate('/autores'))
      .catch(err => console.error('Erro ao atualizar:', err));
  };

  if (!autor) return <p>Carregando...</p>;

  return (
    <div>
      <h1>Editar Autor</h1>
      <Form id='frmAutor' onSubmit={handleSubmit}>
        <Form.Group className="mb-2" controlId="formTitulo">
          <Form.Label>Nome</Form.Label>
          <Form.Control type="text" value={autor.nome} onChange={(e) => dispatch({ type: 'autores/updateSelected', payload: { ...autor, nome: e.target.value } })} placeholder="Nome do autor" />
        </Form.Group>
        <Button variant="primary" type="submit">
          Salvar
        </Button>
      </Form>
    </div>
  );
};

export default AutoresEdit;
