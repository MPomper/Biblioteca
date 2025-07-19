import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchAllLivros, deleteLivro } from '../../store/livrosSlice';
import { RootState, AppDispatch } from '../../store/Store';
import { Link } from 'react-router-dom';
import { Button, Table } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Livro } from '../../models/Livro';


const LivrosList = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { data: livros, loading, errors } = useSelector((state: RootState) => state.livros);

  useEffect(() => {
    dispatch(fetchAllLivros());
  }, [dispatch]);

  const confirmDelete = (livro: Livro) =>
    {
      const result = window.confirm(`Tem certeza que deseja excluir o livro "${livro.titulo}"?`);
      if (result) {
        dispatch(deleteLivro(livro.id));
      }
    }

  return (
    <div>
      <div style={{display: "flex", justifyContent: "space-between", alignItems: "center"}}>
        <h1 style={{margin: 0}}>Livros</h1>
        <div style={{display: "flex", gap: "10px"}}>
          <Link to="/livros/buscar"><Button as="input" type="button" value="Buscar Livro"></Button></Link>
          <Link to="/livros/novo"><Button as="input" type="button" value="Adicionar novo Livro"></Button></Link>
        </div>
      </div>
      {loading && <p>Carregando...</p>}
      {errors && <p style={{ color: 'red', margin: 0 }}>Erro: {errors.general}</p>}
      {
        livros.length > 0 ?
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
            {livros.map((livro: Livro) => (
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
        <h4 style={{display: "flex", justifyContent: "center"}}>Não há registros de livro cadastrado.</h4>
      }
    </div>
  );
};

export default LivrosList;
