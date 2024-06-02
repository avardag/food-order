import { toast } from "react-toastify";
import * as userService from "./services/userService";
import { AuthContext } from "./context/AuthContext";
import { useState } from "react";

interface AuthProviderProps {
  children: JSX.Element | JSX.Element[];
  //children: React.ReactNode
}

export const AuthProvider = ({ children }: AuthProviderProps) => {
  const [user, setUser] = useState(userService.getUser());

  async function login(email: string, password: string) {
    try {
      const data = await userService.login(email, password);
      setUser(data);
      toast.success("Login successful");
    } catch (err) {
      // toast.error(err.response.data);
      console.log(err);
    }
  }

  function logout() {
    userService.logout();
    setUser(null);
    toast.success("Logout successful");
  }

  return (
    <AuthContext.Provider value={{ user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};
