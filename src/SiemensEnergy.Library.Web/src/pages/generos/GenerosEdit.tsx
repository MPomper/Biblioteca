import { useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { AppDispatch, RootState } from '../../store/Store';
import { fetchByIdGenero, updateGenero } from '../../store/generosSlice';
import { Button, Form } from 'react-bootstrap';

const GenerosEdit = () => {
  const { id } = useParams();
  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();
  const { selected, errors} = useSelector((state: RootState) => state.generos);

  useEffect(() => {
    if (id) {
      dispatch(fetchByIdGenero(Number(id)));
    }
  }, [dispatch, id]);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!selected) return;
    dispatch(updateGenero({ genero: selected }))
      .unwrap()
      .then(() => navigate('/generos'))
      .catch(err => console.error('Erro ao atualizar:', err));
  };

  if (!selected) return <p>Carregando...</p>;

  return (
    <div>
      <h1>Editar Gênero</h1>
      {errors && <p style={{ color: 'red', margin: 0 }}>Erro: {errors.general}</p>}
      <Form id='frmGenero' onSubmit={handleSubmit}>
        <Form.Group className="mb-2" controlId="formTitulo">
          <Form.Label>Gênero</Form.Label>
          <Form.Control type="text" value={selected.descricao} onChange={(e) => dispatch({ type: 'generos/updateSelected', payload: { ...selected, descricao: e.target.value } })} placeholder="Descrição do gênero" />
          {errors?.Descricao && <p style={{ color: 'red', margin: 0 }}>{errors.Descricao[0]}</p>}
        </Form.Group>
        <Button variant="primary" type="submit">
          Salvar
        </Button>
      </Form>
    </div>
  );
};

export default GenerosEdit;
