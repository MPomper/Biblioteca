import { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState, AppDispatch } from '../../store/Store';
import { deleteLivro, fetchLivroByFiltro } from '../../store/livrosSlice';
import { Link, useNavigate } from 'react-router-dom';
import { Button, Form, Table } from 'react-bootstrap';
import { Autor } from '../../models/Autor';
import { Genero } from '../../models/Genero';
import { Livro } from '../../models/Livro';

const LivrosSearch = () => {
  const [titulo, setTitulo] = useState('');
  const [idAutor, setIdAutor] = useState(0);
  const [idGenero, setIdGenero] = useState(0);
  const [ehFiltrado, setEhFiltrado] = useState(false);

  const dispatch = useDispatch<AppDispatch>();
  const { autoresList, generosList, filtro, errors } = useSelector((state: RootState) => {
    return { autoresList: state.autores, generosList: state.generos, filtro: state.livros.filtro, errors: state.livros.errors };
  });
  
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    dispatch(fetchLivroByFiltro({ titulo, idAutor, idGenero }))
      .unwrap()
      .then(() => {
        setTitulo('');
        setIdAutor(0);
        setIdGenero(0);
        setEhFiltrado(true);
      })
      .catch((err) => console.error(err));
  };

  const confirmDelete = (livro: Livro) =>
  {
    const result = window.confirm(`Tem certeza que deseja excluir o livro "${livro.titulo}"?`);
    if (result) {
      dispatch(deleteLivro(livro.id));
    }
  }

  const limparFormulario = () => { 
    console.log(idGenero);
    setTitulo('');
    setIdAutor(0);
    setIdGenero(0);
    setEhFiltrado(false);
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
              <option value={0}>Todos</option>
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
              <option value={0}>Todos</option>
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
        <div style={{ display: ehFiltrado ? 'block' : 'none' }}>
          {
            filtro.length > 0 ?
            <Table responsive='sm'>
              <thead>
                <tr>
                  <th>Ações</th>
                  <th>Título</th>
                  <th>Gênero</th>
                  <th>Autor</th>
                </tr>
              </thead>
              <tbody>
                {filtro.map((livro: Livro) => (
                  <tr>
                    <td>
                      <div>
                        <Link to={`/livros/${livro.id}/editar`}><Button as="input" type="button" value="Editar" size="sm"></Button></Link>
                        <Button as="input" style={{marginLeft: 10}} type="button" variant='danger' value="Excluir" size="sm" onClick={() => confirmDelete(livro)}></Button>
                      </div>
                    </td>
                    <td>{livro.titulo}</td>
                    <td>{livro.genero ?? ''}</td>
                    <td>{livro.autor ?? ''}</td>
                  </tr>
                ))}
              </tbody>
            </Table>
            :
            <h4 style={{display: "flex", justifyContent: "center"}}>Não há registros de livro encontrado.</h4>
          }
        </div>
    </div>
  );
};

export default LivrosSearch;
