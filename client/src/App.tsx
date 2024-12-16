import { useEffect } from "react";
import AppRoutes from "./AppRoutes";
import Header from "./components/Header";
import setLoadingInterceptor from "./interceptors/loadinginterceptor";
import { useLoading } from "./hooks/useLoading";
import Loading from "./components/Loading";

function App() {
  const { showLoading, hideLoading } = useLoading();

  useEffect(() => {
    setLoadingInterceptor({ showLoading, hideLoading });
  }, []);
  return (
    <>
      <Loading />
      <Header />
      <AppRoutes />
    </>
  );
}

export default App;
