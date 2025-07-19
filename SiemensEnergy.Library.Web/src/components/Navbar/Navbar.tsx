import { Link, NavLink } from 'react-router-dom';
import './Navbar.css';

const Navbar = () => {
  return (
    <nav className="navbar">
      <h2><Link to="/">Siemens Energy - Biblioteca</Link></h2>
      <div className="nav-links">
        <NavLink to="/">Home</NavLink>
        <NavLink to="/livros">Livros</NavLink>
        <NavLink to="/autores">Autores</NavLink>
        <NavLink to="/generos">Gêneros</NavLink>
      </div>
    </nav>
  );
};

export default Navbar;
