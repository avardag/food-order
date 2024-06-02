import { createContext } from "react";
import { IUser } from "../shared/types";

export interface IAuthContext {
  user: IUser | null;
  login: (email: string, password: string) => void;
  logout: () => void;
}

export const AuthContext = createContext<IAuthContext | null>(null);
