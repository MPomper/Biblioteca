import { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState, AppDispatch } from '../../store/Store';
import { createAutor } from '../../store/autoresSlice';
import { useNavigate } from 'react-router-dom';
import { Button, Form } from 'react-bootstrap';

const AutoresCreate = () => {
  const [nome, setNome] = useState('');

  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();
  const errors = useSelector((state: RootState) => state.autores.errors);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    dispatch(createAutor({ nome }))
      .unwrap()
      .then(() => {
        setNome('');
        navigate('/autores');
      })
      .catch((err) => console.error(err));
  };

  const limparFormulario = () => { 
    setNome('');
  }

  return (
    <div>
      <h1>Novo Autor</h1>
      <Form id='frmAutor' onSubmit={handleSubmit}>
          <Form.Group className="mb-2" controlId="formTitulo">
            <Form.Label>Autor</Form.Label>
            <Form.Control type="text" value={nome} onChange={(e) => setNome(e.target.value)} placeholder="Nome do autor" />
            {errors?.Nome && <p style={{ color: 'red', margin: 0 }}>{errors.Nome[0]}</p>}
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

export default AutoresCreate;
