import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import "./index.css";
import { BrowserRouter } from "react-router-dom";
import { CartStoreProvider } from "./cartState.tsx";
import "./axiosConfig.ts";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <BrowserRouter>
      <CartStoreProvider>
        <App />
      </CartStoreProvider>
    </BrowserRouter>
  </React.StrictMode>,
);
