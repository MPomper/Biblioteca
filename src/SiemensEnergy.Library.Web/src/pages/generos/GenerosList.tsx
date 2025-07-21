import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchAllGeneros, deleteGenero } from '../../store/generosSlice';
import { RootState, AppDispatch } from '../../store/Store';
import { Link } from 'react-router-dom';
import { Button, Table } from 'react-bootstrap';
import { Genero } from '../../models/Genero';
import 'bootstrap/dist/css/bootstrap.min.css';


const GenerosList = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { data: generos, loading, errors } = useSelector((state: RootState) => state.generos);
  
  useEffect(() => {
    dispatch(fetchAllGeneros());
  }, [dispatch]);

  const confirmDelete = (genero: Genero) =>
  {
    const result = window.confirm(`Tem certeza que deseja excluir o gênero "${genero.descricao}"?`);
    if (result) {
      dispatch(deleteGenero(genero.id));
    }
  }

  return (
    <div>
      <div style={{display: "flex", justifyContent: "space-between", alignItems: "center"}}>
        <h1 style={{margin: 0}}>Gêneros</h1>
        <div style={{display: "flex", gap: "10px"}}>
          <Link to="/generos/buscar"><Button as="input" style={{left: 0}} type="button" value="Buscar Gênero"></Button></Link>
          <Link to="/generos/novo"><Button as="input" style={{left: 0}} type="button" value="Adicionar novo Gênero"></Button></Link>
        </div>
      </div>
      {loading && <p>Carregando...</p>}
      {errors && <p style={{ color: 'red', margin: 0 }}>Erro: {errors.general}</p>}
      {
        generos.length > 0 ?
        <Table responsive='sm'>
          <thead>
            <tr>
              <th>Ações</th>
              <th>Gênero</th>
              <th>Livros</th>
            </tr>
          </thead>
          <tbody>
            {generos.map((genero: Genero) => (
              <tr>
                <td>
                  <div>
                    <Link to={`/generos/${genero.id}/editar`}><Button as="input" type="button" value="Editar" size="sm"></Button></Link>
                    <Button as="input" style={{marginLeft: 10}} type="button" variant='danger' value="Excluir" size="sm" onClick={() => confirmDelete(genero)}></Button>
                  </div>
                </td>
                <td>{genero.descricao}</td>
                <td>{genero.livros.join(', ')}</td>
              </tr>
            ))}
          </tbody>
        </Table>
        :
        <h4 style={{display: "flex", justifyContent: "center"}}>Não há registros de gênero de livro cadastrado.</h4>
      }
    </div>
  );
};

export default GenerosList;
