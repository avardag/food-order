import { useEffect } from "react";
import { toast } from "react-toastify";
import { SubmitHandler, useForm } from "react-hook-form";
import {
  Link,
  useLocation,
  useNavigate,
  useSearchParams,
} from "react-router-dom";
import { useAuth } from "../../hooks/useAuth";
import Title from "../../components/Title";
import Input from "../../components/Input";
import Button from "../../components/Button";

interface IFormInput {
  email: string;
  password: string;
}

export default function LoginPage() {
  const {
    handleSubmit,
    register,
    formState: { errors },
  } = useForm<IFormInput>();

  const navigate = useNavigate();
  const location = useLocation();
  const { user, login } = useAuth();
  const [params] = useSearchParams();
  const returnUrl = params.get("returnUrl");
  const from = location.state?.from?.pathname || "/";

  useEffect(() => {
    if (!user) return;
    //if there is a user redirect to returnUrl or home
    returnUrl ? navigate(returnUrl) : navigate("/");
  }, [user, returnUrl, navigate]);

  const onSubmit: SubmitHandler<IFormInput> = async ({ email, password }) => {
    try {
      await login({ email, password });
      toast.success("Login successful");
      // Send them back to the page they tried to visit when they were
      // redirected to the login page. Use { replace: true } so we don't create
      // another entry in the history stack for the login page.
      navigate(from, { replace: true });
    } catch (err) {
      toast.error("Login failed");
    }
  };
  return (
    <div className="flex justify-center items-center h-full mt-12">
      <div className="w-96">
        <Title title="Login" fontSize={32} margin="1.5rem 0" />
        <form
          onSubmit={handleSubmit(onSubmit)}
          noValidate
          className="flex flex-col justify-center"
        >
          <Input
            type="email"
            label="Email"
            {...register("email", {
              required: true,
              pattern: {
                value: /^[\w-.]+@([\w-]+\.)+[\w-]{2,63}$/i,
                message: "Email Is Not Valid",
              },
            })}
            error={errors.email}
          />

          <Input
            type="password"
            label="Password"
            {...register("password", {
              required: true,
            })}
            error={errors.password}
          />

          <Button type="submit" text="Login" />

          <div className="flex justify-center items-center">
            New user? &nbsp;
            <Link
              to={`/register${returnUrl ? "?returnUrl=" + returnUrl : ""}`}
              className="text-red-600"
            >
              Register here
            </Link>
          </div>
        </form>
      </div>
    </div>
  );
}
