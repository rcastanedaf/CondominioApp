import Banco from "./components/Banco";
import ConceptoDescuento from "./components/ConceptoDescuento";

function App() {
  return (
    <div style={{ padding: "40px" }}>
      <h1>Bancos</h1>
      <Banco />
      <h1>Concepto Descuento</h1>
      <ConceptoDescuento />
    </div>
  );
}

export default App;