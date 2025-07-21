// src/App.tsx
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Navbar from '../components/Navbar/Navbar';
import Home from '../pages/home/Home';
import LivrosList from '../pages/livros/LivrosList';
import LivrosSearch from '../pages/livros/LivrosSearch';
import LivrosCreate from '../pages/livros/LivrosCreate';
import LivrosEdit from '../pages/livros/LivrosEdit';
import AutoresList from '../pages/autores/AutoresList';
import AutoresSearch from '../pages/autores/AutoresSearch';
import AutoresCreate from '../pages/autores/AutoresCreate';
import AutoresEdit from '../pages/autores/AutoresEdit';
import GenerosList from '../pages/generos/GenerosList';
import GenerosSearch from '../pages/generos/GenerosSearch';
import GenerosCreate from '../pages/generos/GenerosCreate';
import GenerosEdit from '../pages/generos/GenerosEdit';

function App() {
  return (
    <BrowserRouter>
      <Navbar/>
      <div style={{ height: '100%', padding: '20px' }}>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/livros" element={<LivrosList />} />
          <Route path="/livros/buscar" element={<LivrosSearch />} />
          <Route path="/livros/novo" element={<LivrosCreate />} />
          <Route path="/livros/:id/editar" element={<LivrosEdit />} />
          <Route path="/autores" element={<AutoresList />} />
          <Route path="/autores/buscar" element={<AutoresSearch />} />
          <Route path="/autores/novo" element={<AutoresCreate />} />
          <Route path="/autores/:id/editar" element={<AutoresEdit />} />
          <Route path="/generos" element={<GenerosList />} />
          <Route path="/generos/buscar" element={<GenerosSearch />} />
          <Route path="/generos/novo" element={<GenerosCreate />} />
          <Route path="/generos/:id/editar" element={<GenerosEdit />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
