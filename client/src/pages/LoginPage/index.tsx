import { useEffect } from "react";
import { SubmitHandler, useForm } from "react-hook-form";
import { Link, useNavigate, useSearchParams } from "react-router-dom";
import { useAuth } from "../../hooks/useAuth";
import styles from "./loginPage.module.css";
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
  const { user, login } = useAuth();
  const [params] = useSearchParams();
  const returnUrl = params.get("returnUrl");

  useEffect(() => {
    if (!user) return;
    //if there is a user redirect to returnUrl or home
    returnUrl ? navigate(returnUrl) : navigate("/");
  }, [user]);

  const onSubmit: SubmitHandler<IFormInput> = async ({ email, password }) => {
    await login(email, password);
  };
  return (
    <div className={styles.container}>
      <div className={styles.details}>
        <Title title="Login" />
        <form onSubmit={handleSubmit(onSubmit)} noValidate>
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

          <div className={styles.register}>
            New user? &nbsp;
            <Link to={`/register${returnUrl ? "?returnUrl=" + returnUrl : ""}`}>
              Register here
            </Link>
          </div>
        </form>
      </div>
    </div>
  );
}
