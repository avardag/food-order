import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import "./index.css";
import { BrowserRouter } from "react-router-dom";
import { CartStoreProvider } from "./cartState.tsx";
import "./axiosConfig.ts";
import "react-toastify/dist/ReactToastify.css";
import { AuthProvider } from "./authState.tsx";
import { ToastContainer } from "react-toastify";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <BrowserRouter>
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
    </BrowserRouter>
  </React.StrictMode>
);
