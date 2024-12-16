import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import "./index.css";
import { BrowserRouter } from "react-router-dom";
import { CartStoreProvider } from "./state/cartState.tsx";
import "./axiosConfig.ts";
import "react-toastify/dist/ReactToastify.css";
import { AuthProvider } from "./state/authState.tsx";
import { ToastContainer } from "react-toastify";
import { LoadingProvider } from "./state/loadingState.tsx";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <BrowserRouter>
      <LoadingProvider>
        <AuthProvider>
          <CartStoreProvider>
            <App />
            <ToastContainer
              position="bottom-right"
              autoClose={3000}
              hideProgressBar={false}
              newestOnTop={false}
              closeOnClick
              rtl={false}
              pauseOnFocusLoss
              draggable
              pauseOnHover
              theme="light"
            />
          </CartStoreProvider>
        </AuthProvider>
      </LoadingProvider>
    </BrowserRouter>
  </React.StrictMode>
);
