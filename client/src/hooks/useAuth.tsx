import { useContext } from "react";
import { AuthContext, IAuthContext } from "../context/AuthContext";

export const useAuth = () => {
  const { user, login, logout } = useContext(AuthContext) as IAuthContext;

  return { user, login, logout };
};
