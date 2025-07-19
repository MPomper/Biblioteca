import { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState, AppDispatch } from '../../store/Store';
import { createLivro } from '../../store/livrosSlice';
import { useNavigate } from 'react-router-dom';
import { Button, Form } from 'react-bootstrap';
import { Autor } from '../../models/Autor';
import { Genero } from '../../models/Genero';

const LivrosSearch = () => {
  const [titulo, setTitulo] = useState('');
  const [idAutor, setIdAutor] = useState(0);
  const [idGenero, setIdGenero] = useState(0);

  const dispatch = useDispatch<AppDispatch>();
  const { autoresList, generosList, errors } = useSelector((state: RootState) => {
    return { autoresList: state.autores, generosList: state.generos, errors: state.livros.errors };
  });
  const navigate = useNavigate();

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    dispatch(createLivro({ titulo, idAutor, idGenero }))
      .unwrap()
      .then(() => {
        setTitulo('');
        setIdAutor(0);
        setIdGenero(0);
        navigate('/livros');
      })
      .catch((err) => console.error(err));
  };

  const limparFormulario = () => { 
    console.log(idGenero);
    setTitulo('');
    setIdAutor(0);
    setIdGenero(0);
  }

  return (
    <div>
      <h1>Buscar Livros</h1>
      <Form id='frmLivro' onSubmit={handleSubmit}>
          <Form.Group className="mb-2" controlId="formTitulo">
            <Form.Label>Título</Form.Label>
            <Form.Control type="text" value={titulo} onChange={(e) => setTitulo(e.target.value)} placeholder="Titulo do livro" />
          </Form.Group>
          <Form.Group className="mb-2" controlId="formAutor">
            <Form.Label>Autor</Form.Label>
            <Form.Select aria-label="Default select example" value={idAutor ?? ''} onChange={(e) => setIdAutor(Number(e.target.value))}>
              <option value="">Todos</option>
              {
                autoresList.data.map((autor: Autor) => (
                  <option value={autor.id}>{autor.nome}</option>
                ))
              }
            </Form.Select>
          </Form.Group>
          <Form.Group className="mb-2" controlId="formGenero">
            <Form.Label>Gênero</Form.Label>
            <Form.Select aria-label="Default select example" value={idGenero ?? ''} onChange={(e) => setIdGenero(Number(e.target.value))}>
              <option value="">Todos</option>
              {
                generosList.data.map((genero: Genero) => (
                  <option value={genero.id}>{genero.descricao}</option>
                ))
              }
            </Form.Select>
          </Form.Group>
          <Button variant="primary" style={{marginRight: "2px"}} type="button" onClick={limparFormulario}>
            Limpar
          </Button>
          <Button variant="primary" type="submit">
            Buscar
          </Button>
        </Form>
    </div>
  );
};

export default LivrosSearch;
