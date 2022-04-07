import './App.css';
import { PlanetInfo } from './planetInfo/planetInfo';

function App() {
  return (
    <div className="App" id='app'>
      <main style={{backgroundImage: "url(/img/background.webp)", backgroundSize: 'cover', padding: '2% 0 10% 0'}}>
        <PlanetInfo />
      </main>
    </div>
  );
}

export default App;
