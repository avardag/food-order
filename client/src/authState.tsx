import * as userService from "./services/userService";
import { AuthContext } from "./context/AuthContext";
import { useState } from "react";
import { IUserRegisterDto, LoginInput } from "./shared/types";

interface AuthProviderProps {
  children: JSX.Element | JSX.Element[];
  //children: React.ReactNode
}

export const AuthProvider = ({ children }: AuthProviderProps) => {
  const [user, setUser] = useState(userService.getUser());

  async function login({ email, password }: LoginInput) {
    try {
      const data = await userService.loginUser({ email, password });
      setUser(data);
    } catch (err) {
      console.log(err);
      throw err;
    }
  }

  async function register(userData: IUserRegisterDto) {
    try {
      const data = await userService.registerUser(userData);
      setUser(data);
    } catch (err) {
      console.log(err);
      throw err;
    }
  }

  function logout() {
    userService.logout();
    setUser(null);
  }

  return (
    <AuthContext.Provider value={{ user, login, logout, register }}>
      {children}
    </AuthContext.Provider>
  );
};
