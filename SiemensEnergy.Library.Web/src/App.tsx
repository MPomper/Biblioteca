import { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import Route from './routes/Routes'
import { fetchAllAutores } from './store/autoresSlice';
import { fetchAllGeneros } from './store/generosSlice';
import { AppDispatch } from './store/Store';

const App = () => {
  const dispatch = useDispatch<AppDispatch>();

  useEffect(() => {
    dispatch(fetchAllAutores());
    dispatch(fetchAllGeneros());
  }, [dispatch]);

  return (
    <Route/>
  );
}

export default App;
