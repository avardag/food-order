import { useLoading } from "../../hooks/useLoading";

export default function Loading() {
  const { isLoading } = useLoading();
  if (!isLoading) return;

  return (
    <div className="fixed w-full h-full bg-slate-200/70 z-50 left-0 top-0">
      <div className="flex flex-col justify-center items-center h-4/5 w-full">
        <img
          src="/fade-stagger-circles.svg"
          alt="Loading!"
          className="h-80 border-b-8 border-b-blue-300 border-solid"
        />
        <h1 className="text-blue-400 lowercase">Loading...</h1>
      </div>
    </div>
  );
}
