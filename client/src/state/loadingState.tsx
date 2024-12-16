import { useState } from "react";
import { LoadingContext } from "../context/LoadingContext";

interface LoadingProviderProps {
  children: JSX.Element | JSX.Element[];
  //children: React.ReactNode
}

export const LoadingProvider = ({ children }: LoadingProviderProps) => {
  const [isLoading, setIsLoading] = useState(false);

  const showLoading = () => setIsLoading(true);
  const hideLoading = () => setIsLoading(false);

  return (
    <LoadingContext.Provider value={{ isLoading, showLoading, hideLoading }}>
      {children}
    </LoadingContext.Provider>
  );
};
