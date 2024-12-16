import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

interface SearchProps {
  searchRoute?: string;
  defaultRoute?: string;
  margin?: string;
  placeholder?: string;
}

export default function Search({
  searchRoute = "/search/",
  defaultRoute = "/",
  placeholder = "Search your favorite food...",
  margin,
}: SearchProps) {
  const [term, setTerm] = useState("");
  const navigate = useNavigate();
  const { searchTerm } = useParams();

  useEffect(() => {
    setTerm(searchTerm ?? "");
  }, [searchTerm]);

  const search = () => {
    term ? navigate(searchRoute + term) : navigate(defaultRoute);
  };
  return (
    <div className="flex justify-center mt-12 mb-6" style={{ margin }}>
      <input
        className="h-12 w-80 bg-gray-200 text-base font-medium p-4 rounded-[10rem_0_0_10rem] border-none outline-none"
        type="text"
        placeholder={placeholder}
        onChange={(e) => setTerm(e.target.value)}
        onKeyUp={(e) => e.key === "Enter" && search()}
        value={term}
      />
      <button
        className="h-12 w-20 text-base bg-red-600 text-white opacity-90 rounded-[0_10rem_10rem_0] border-none hover:opacity-100 hover:cursor-pointer"
        onClick={search}
      >
        Search
      </button>
    </div>
  );
}
