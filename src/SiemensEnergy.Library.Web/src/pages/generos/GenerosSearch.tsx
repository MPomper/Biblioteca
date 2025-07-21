import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState, AppDispatch } from '../../store/Store';
import { fetchAllGeneros, deleteGenero } from '../../store/generosSlice';
import { Genero } from '../../models/Genero';
import { Link } from 'react-router-dom';
import { Table, Button, Form } from 'react-bootstrap';

const GenerosSearch = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { data: generos, loading, errors } = useSelector((state: RootState) => state.generos);
  const [filtro, setFiltro] = useState('');

  useEffect(() => {
    dispatch(fetchAllGeneros());
  }, [dispatch]);

  const generosFiltrados = generos.filter(genero =>
    genero.descricao.toLowerCase().includes(filtro.toLowerCase())
  );

  const confirmarExclusao = (genero: Genero) => {
    if (window.confirm(`Deseja excluir o gênero "${genero.descricao}"?`)) {
      dispatch(deleteGenero(genero.id));
    }
  };

  return (
    <div>
      <h1>Buscar Generos</h1>
      <Form.Control
        type="text"
        placeholder="Digite o nome do genero"
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
          {generosFiltrados.map((genero) => (
            <tr key={genero.id}>
              <td>
                <Link to={`/generos/${genero.id}/editar`}>
                  <Button size="sm">Editar</Button>
                </Link>{' '}
                <Button size="sm" variant="danger" onClick={() => confirmarExclusao(genero)}>
                  Excluir
                </Button>
              </td>
              <td>{genero.descricao}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};

export default GenerosSearch;
