import { useEffect } from "react";
import { SubmitHandler, useForm } from "react-hook-form";
import { Link } from "react-router-dom";
import { useSearchParams, useNavigate } from "react-router-dom";
import { useAuth } from "../../hooks/useAuth";
import Title from "../../components/Title";
import Input from "../../components/Input";
import Button from "../../components/Button";
import { toast } from "react-toastify";

const EMAIL = {
  value: /^[\w-.]+@([\w-]+\.)+[\w-]{2,63}$/i,
  message: "Email Is Not Valid",
};

interface IRegisterFormInput {
  username: string;
  email: string;
  password: string;
  confirmPassword: string;
  firstName?: string;
  lastName?: string;
}

export default function RegisterPage() {
  const auth = useAuth();
  const { user, register: registerUser } = auth;
  const navigate = useNavigate();
  const [params] = useSearchParams();
  const returnUrl = params.get("returnUrl");

  useEffect(() => {
    if (!user) return;
    returnUrl ? navigate(returnUrl) : navigate("/");
  }, [user, navigate, returnUrl]);

  const {
    handleSubmit,
    register,
    getValues,
    formState: { errors },
  } = useForm<IRegisterFormInput>();

  const submit: SubmitHandler<IRegisterFormInput> = async (data) => {
    try {
      await registerUser(data);
      toast.success("Register Successful");
    } catch (err) {
      console.log(err);
      toast.error("Register Failed");
    }
  };

  return (
    <div className="flex justify-center items-center h-full mt-12">
      <div className="w-96">
        <Title title="Register" />
        <form
          onSubmit={handleSubmit(submit)}
          noValidate
          className="flex flex-col justify-center"
        >
          <Input
            type="text"
            label="Username"
            {...register("username", {
              required: true,
              minLength: 4,
            })}
            error={errors.username}
          />

          <Input
            type="email"
            label="Email"
            {...register("email", {
              required: true,
              pattern: EMAIL,
            })}
            error={errors.email}
          />

          <Input
            type="password"
            label="Password"
            {...register("password", {
              required: true,
              minLength: 5,
            })}
            error={errors.password}
          />

          <Input
            type="password"
            label="Confirm Password"
            {...register("confirmPassword", {
              required: true,
              validate: (value) =>
                value !== getValues("password")
                  ? "Passwords Do No Match"
                  : true,
            })}
            error={errors.confirmPassword}
          />

          <Input
            type="text"
            label="First Name"
            {...register("firstName", {
              required: false,
              minLength: 2,
            })}
            error={errors.firstName}
          />
          <Input
            type="text"
            label="Last Name"
            {...register("lastName", {
              required: false,
              minLength: 2,
            })}
            error={errors.lastName}
          />

          <Button type="submit" text="Register" />

          <div className="flex justify-center items-center">
            Already a user? &nbsp;
            <Link to={`/login${returnUrl ? "?returnUrl=" + returnUrl : ""}`}>
              Login here
            </Link>
          </div>
        </form>
      </div>
    </div>
  );
}
