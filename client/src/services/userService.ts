import axios from "axios";
import { IUser } from "../shared/types";

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
  // status: number;
}

export const login = async (email: string, password: string) => {
  try {
    const { data } = await axios.post("api/account/login", { email, password });
    localStorage.setItem("user", JSON.stringify(data));
    return data;
  } catch (err) {
    if (axios.isAxiosError(err)) {
      // Access to config, request, and response
      // return { message: err.message, status: err.status };
      return { message: err.message };
    } else if (err instanceof Error) {
      // Just a stock error
      return { message: err.message };
    } else {
      // unknown
      throw new Error("different error than axios");
    }
  }
};

// export const login = async (
//   email: string,
//   password: string,
// ): Promise<ApiResponse | ApiError> => {
//   try {
//     const { data } = await axios.post("api/account/login", { email, password });
//     localStorage.setItem("user", JSON.stringify(data));
//     return data;
//   } catch (err) {
//     if (axios.isAxiosError(err)) {
//       // Access to config, request, and response
//       // return { message: err.message, status: err.status };
//       return { message: err.message };
//     } else if (err instanceof Error) {
//       // Just a stock error
//       return { message: err.message };
//     } else {
//       // unknown
//       throw new Error("different error than axios");
//     }
//   }
// };
//
export const logout = () => localStorage.removeItem("user");
