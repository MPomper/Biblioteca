import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchAllAutores, deleteAutor } from '../../store/autoresSlice';
import { RootState, AppDispatch } from '../../store/Store';
import { Link } from 'react-router-dom';
import { Button, Table } from 'react-bootstrap';
import { Autor } from '../../models/Autor';
import 'bootstrap/dist/css/bootstrap.min.css';


const AutoresList = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { data: autores, loading, errors } = useSelector((state: RootState) => state.autores);

  useEffect(() => {
    dispatch(fetchAllAutores());
  }, [dispatch]);

  const confirmDelete = (autor: Autor) =>
  {
    const result = window.confirm(`Tem certeza que deseja excluir o autor(a) "${autor.nome}"?`);
    if (result) {
      dispatch(deleteAutor(autor.id));
    }
    console.log(errors);
  }

  return (
    <div>
      <div style={{display: "flex", justifyContent: "space-between", alignItems: "center"}}>
        <h1 style={{margin: 0}}>Autores</h1>
        <div style={{display: "flex", gap: "10px"}}>
          <Link to="/autores/buscar"><Button as="input" style={{left: 0}} type="button" value="Buscar Autor"></Button></Link>
          <Link to="/autores/novo"><Button as="input" style={{left: 0}} type="button" value="Adicionar novo Autor"></Button></Link>
        </div>
      </div>
      {loading && <p>Carregando...</p>}
      {errors && <p style={{ color: 'red', margin: 0 }}>Erro: {errors.general}</p>}
      {
        autores.length > 0 ?
        <Table responsive='sm'>
          <thead>
            <tr>
              <th>Ações</th>
              <th>Autor</th>
              <th>Livros</th>
            </tr>
          </thead>
          <tbody>
            {autores.map((autor: Autor) => (
              <tr>
                <td>
                  <div>
                    <Link to={`/autores/${autor.id}/editar`}><Button as="input" type="button" value="Editar" size="sm"></Button></Link>
                    <Button as="input" style={{marginLeft: 10}} type="button" variant='danger' value="Excluir" size="sm" onClick={() => confirmDelete(autor)}></Button>
                  </div>
                </td>
                <td>{autor.nome}</td>
                <td>{autor?.livros?.length > 0 ? autor.livros.join(', ') : ''}</td>
              </tr>
            ))}
          </tbody>
        </Table>
        :
        <h4 style={{display: "flex", justifyContent: "center"}}>Não há registros de autor de livro cadastrado.</h4>
      }
    </div>
  );
};

export default AutoresList;
