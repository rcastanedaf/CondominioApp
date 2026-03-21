import Pais from "./components/Pais";
import Parentesco from "./components/Parentesco";

function App() {
  return (
    <div style={{ padding: "40px" }}>
      <h1>Paises</h1>
      <Pais />
      <h1>Parentesco</h1>
      <Parentesco />
    </div>
  );
}

export default App;