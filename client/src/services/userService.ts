import axios from "axios";
import { IUser, IUserRegisterDto, LoginInput } from "../shared/types";
import { handleErrorResponse } from "../utils";

export const getUser = () => {
  const user = localStorage.getItem("user");
  return user ? (JSON.parse(user) as IUser) : null;
};

interface ApiResponse {
  data: IUser;
  // status: number;
}

interface ApiError {
  message: string;
  status: number;
}

export const loginUser = async ({
  email,
  password,
}: LoginInput): Promise<IUser> => {
  try {
    const { data } = await axios.post("api/account/login", { email, password });
    localStorage.setItem("user", JSON.stringify(data));
    return data;
  } catch (err) {
    throw handleErrorResponse(err);
  }
};

export const registerUser = async (
  registerData: IUserRegisterDto
): Promise<IUser> => {
  try {
    const { data } = await axios.post("api/account/register", registerData);
    localStorage.setItem("user", JSON.stringify(data));
    return data;
  } catch (err) {
    throw handleErrorResponse(err);
  }
};

export const logout = () => localStorage.removeItem("user");
