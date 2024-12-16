import { Routes, Route } from "react-router-dom";
import HomePage from "./pages/HomePage";
import FoodPage from "./pages/FoodPage";
import CartPage from "./pages/CartPage";
import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";
import AuthenticationGuard from "./components/AuthGuard";
import CheckoutPage from "./pages/CheckoutPage";

export default function AppRoutes() {
  return (
    <Routes>
      <Route path="/" element={<HomePage />} />
      <Route path="/search/:searchTerm" element={<HomePage />} />
      <Route path="/tag/:tagName" element={<HomePage />} />
      <Route path="/food/:foodId" element={<FoodPage />} />
      <Route path="/cart" element={<CartPage />} />
      {/* Protect route based on authentication */}
      <Route element={<AuthenticationGuard />}>
        <Route path="/checkout" element={<CheckoutPage />} />
      </Route>

      {/* Login page in case unauthenticated */}
      <Route element={<AuthenticationGuard guardType="unauthenticated" />}>
        <Route path="/login" element={<LoginPage />} />
        <Route path="/register" element={<RegisterPage />} />{" "}
      </Route>
    </Routes>
  );
}
