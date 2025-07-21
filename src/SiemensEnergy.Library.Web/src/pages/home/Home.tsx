import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState, AppDispatch } from '../../store/Store';
import { fetchAllLivros } from '../../store/livrosSlice';
import { fetchAllAutores } from '../../store/autoresSlice';
import { fetchAllGeneros } from '../../store/generosSlice';
import './Home.css';
import { Button, Image, Table } from 'react-bootstrap';
import { Livro } from '../../models/Livro';
import { Autor } from '../../models/Autor';
import { Genero } from '../../models/Genero';

const Home = () => {
    const [ehHidden, setEhHidden] = useState([{hide: true, button: 'Livros'}, {hide: true, button: 'Autores'}, {hide: true, button: 'Generos'}]);
    const dispatch = useDispatch<AppDispatch>();
    const { livrosList, autoresList, generosList } = useSelector((state: RootState) => {
        return { livrosList: state.livros.data, autoresList: state.autores.data, generosList: state.generos.data };
    });

    useEffect(() => {
        dispatch(fetchAllLivros());
        dispatch(fetchAllAutores());
        dispatch(fetchAllGeneros());
    }, [dispatch]);

    const handleHidden = (type: String) => {
        setEhHidden(prevState =>
                    prevState.map(item =>
                      item.button === type
                        ? { ...item, hide: !item.hide }
                        : { ...item, hide: true }
                    )
        );
    }

    return (
    <div>
        <div className='DescricaoHome'>
            <p>Bem vindo a biblioteca da Siemens Energy, aqui você irá encontrar Livros, Autores e Gêneros.</p>
        </div>
        <div className='ButtonsHome'>
            <Button type="button" onClick={() => handleHidden("Livros")} variant="outline-primary" className='ButtonHome' value="Livros">LIVROS</Button>
            <Button type="button" onClick={() => handleHidden("Autores")} variant="outline-primary" className='ButtonHome' value="Autores">AUTORES</Button>
            <Button type="button" onClick={() => handleHidden("Generos")} variant="outline-primary" className='ButtonHome' value="Gêneros">GÊNEROS</Button>
        </div>
        <div className='GridHome' style={{ display: ehHidden[0].hide ? 'none' : 'block' }}>
            {
                livrosList.length > 0 ?
                <Table responsive='sm'>
                  <thead>
                    <tr>
                      <th>Título</th>
                      <th>Gênero</th>
                      <th>Autor</th>
                    </tr>
                  </thead>
                  <tbody>
                    {livrosList.map((livro: Livro) => (
                      <tr>
                        <td>{livro.titulo}</td>
                        <td>{livro.genero ?? ''}</td>
                        <td>{livro.autor ?? ''}</td>
                      </tr>
                    ))}
                  </tbody>
                </Table>
                :
                <h3>Não há livros cadastrados.</h3>
            }
        </div>
        <div className='GridHome' style={{ display: ehHidden[1].hide ? 'none' : 'block' }}>
            {
                autoresList.length > 0 ?
                <Table responsive='sm'>
                  <thead>
                    <tr>
                      <th>Autor</th>
                      <th>Livros</th>
                    </tr>
                  </thead>
                  <tbody>
                    {autoresList.map((autor: Autor) => (
                      <tr>
                        <td>{autor.nome}</td>
                        <td>{autor?.livros?.length > 0 ? autor.livros.join(', ') : ''}</td>
                      </tr>
                    ))}
                  </tbody>
                </Table>
                :
                <h3>Não há autores cadastrados.</h3>
            }
        </div>
        <div className='GridHome' style={{ display: ehHidden[2].hide ? 'none' : 'block' }}>
            {
                generosList.length > 0 ?
                <Table responsive='sm'>
                  <thead>
                    <tr>
                      <th>Gênero</th>
                      <th>Livros</th>
                    </tr>
                  </thead>
                  <tbody>
                    {generosList.map((genero: Genero) => (
                      <tr>
                        <td>{genero.descricao}</td>
                        <td>{genero?.livros?.length > 0 ? genero.livros.join(', ') : ''}</td>
                      </tr>
                    ))}
                  </tbody>
                </Table>
                :
                <h3>Não há gêneros cadastrados.</h3>
            }
        </div>
    </div>
    );
}

export default Home;