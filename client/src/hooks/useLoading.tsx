import { useContext } from "react";
import { ILoadingContext, LoadingContext } from "../context/LoadingContext";

export const useLoading = () => {
  const { isLoading, showLoading, hideLoading } = useContext(
    LoadingContext
  ) as ILoadingContext;

  return { isLoading, showLoading, hideLoading };
};
