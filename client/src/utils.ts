import axios from "axios";
import { CustomError } from "./shared/types";

export const handleErrorResponse = (err: unknown): CustomError => {
  console.error(err);

  if (axios.isAxiosError(err)) {
    const errorData = err.response?.data;
    return {
      message: errorData?.message || "An unexpected error occurred",
      statusCode: errorData?.statusCode,
      error: errorData?.error,
    };
  } else if (err instanceof Error) {
    return { message: err.message };
  } else {
    console.error("Unknown error:", err);
    throw new Error("An unexpected error occurred");
  }
};
