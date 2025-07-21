import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState, AppDispatch } from '../../store/Store';
import { fetchAllAutores, deleteAutor } from '../../store/autoresSlice';
import { Autor } from '../../models/Autor';
import { Link } from 'react-router-dom';
import { Table, Button, Form } from 'react-bootstrap';

const AutoresSearch = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { data: autores, loading, errors } = useSelector((state: RootState) => state.autores);
  const [filtro, setFiltro] = useState('');

  useEffect(() => {
    dispatch(fetchAllAutores());
  }, [dispatch]);

  const autoresFiltrados = autores.filter(autor =>
    autor.nome.toLowerCase().includes(filtro.toLowerCase())
  );

  const confirmarExclusao = (autor: Autor) => {
    if (window.confirm(`Deseja excluir o autor "${autor.nome}"?`)) {
      dispatch(deleteAutor(autor.id));
    }
  };

  return (
    <div>
      <h1>Buscar Autores</h1>
      <Form.Control
        type="text"
        placeholder="Digite o nome do autor"
        value={filtro}
        onChange={(e) => setFiltro(e.target.value)}
        className="mb-3"
      />
      {loading && <p>Carregando...</p>}
      {errors && <p style={{ color: 'red', margin: 0 }}>Erro: {errors.general}</p>}
      <Table>
        <thead>
          <tr>
            <th>Ações</th>
            <th>Nome</th>
          </tr>
        </thead>
        <tbody>
          {autoresFiltrados.map((autor) => (
            <tr key={autor.id}>
              <td>
                <Link to={`/autores/${autor.id}/editar`}>
                  <Button size="sm">Editar</Button>
                </Link>{' '}
                <Button size="sm" variant="danger" onClick={() => confirmarExclusao(autor)}>
                  Excluir
                </Button>
              </td>
              <td>{autor.nome}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};

export default AutoresSearch;
