import { Link, NavLink } from 'react-router-dom';
import './Navbar.css';
import logo from '../../SiemensEnergyLogo.png'
import { Image } from 'react-bootstrap';

const Navbar = () => {
  return (
    <nav className="navbar">
      <Image src={logo} rounded width="8%" />
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
