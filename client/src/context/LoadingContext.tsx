import { createContext } from "react";
export interface ILoadingContext {
  isLoading: boolean;
  showLoading: () => void;
  hideLoading: () => void;
}
export const LoadingContext = createContext<ILoadingContext | null>(null);
