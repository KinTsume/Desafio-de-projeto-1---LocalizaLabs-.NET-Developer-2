import './App.css';
import { Start } from './start/start';

function App() {
  return (
    <div className="App" id='app'>
      <main style={{backgroundImage: "url(/img/spaceBackground.jpg)", backgroundSize: 'cover', padding: '0'}}>
        <Start firstAccess={false} language='english'/>
      </main>
    </div>
  );
}

export default App;
