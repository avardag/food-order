import { createContext } from "react";
import { IUser, IUserRegisterDto, LoginInput } from "../shared/types";

export interface IAuthContext {
  user: IUser | null;
  login: (logindata: LoginInput) => void;
  register: (userData: IUserRegisterDto) => void;
  logout: () => void;
}

export const AuthContext = createContext<IAuthContext | null>(null);
