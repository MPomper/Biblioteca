import { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { AppDispatch, RootState } from '../../store/Store';
import { createGenero } from '../../store/generosSlice';
import { useNavigate } from 'react-router-dom';
import { Button, Form } from 'react-bootstrap';

const GenerosCreate = () => {
  const [descricao, setDescricao] = useState('');

  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();
  const errors = useSelector((state: RootState) => state.generos.errors);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    dispatch(createGenero({ descricao }))
      .unwrap()
      .then(() => {
        setDescricao('');
        navigate('/generos');
      })
      .catch((err) => console.error(err));

  };

  const limparFormulario = () => { 
    setDescricao('');
  }

  return (
    <div>
      <h1>Novo Gênero</h1>
      <Form id='frmGenero' onSubmit={handleSubmit}>
          <Form.Group className="mb-2" controlId="formTitulo">
            <Form.Label>Gênero</Form.Label>
            <Form.Control type="text" value={descricao} onChange={(e) => setDescricao(e.target.value)} placeholder="Descrição do gênero" />
            {errors?.Descricao && <p style={{ color: 'red', margin: 0 }}>{errors.Descricao[0]}</p>}
          </Form.Group>
          <Button variant="primary" style={{marginRight: "2px"}} type="button" onClick={limparFormulario}>
            Limpar
          </Button>
          <Button variant="primary" type="submit">
            Adicionar
          </Button>
        </Form>
    </div>
  );
};

export default GenerosCreate;
