import Header from "../components/Header";
import Footer from "../components/Footer";
import Home from "../pages/Home";

function MainLayout({ component }) {
  return (
    <div className="d-flex flex-column min-vh-100">
      <Header />

      <main className="flex-grow-1 container py-4">
        {component || <Home />}
      </main>
      
      <Footer />
    </div>
  );
}

export default MainLayout;
