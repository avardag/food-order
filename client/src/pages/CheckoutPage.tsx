import { useNavigate } from "react-router-dom";
import { useState } from "react";
import { useForm } from "react-hook-form";
import { toast } from "react-toastify";
import useCart from "../hooks/useCart";
import { useAuth } from "../hooks/useAuth";
import Title from "../components/Title";
import Input from "../components/Input";
import Button from "../components/Button";
export default function CheckoutPage() {
  const { cartItemsm, totalCount, totalQuantity } = useCart();
  const { user } = useAuth();
  const navigate = useNavigate();
  const [order, setOrder] = useState({ ...cartItems });

  const {
    register,
    formState: { errors },
    handleSubmit,
  } = useForm();

  const submit = async (data) => {
    if (!order.addressLatLng) {
      toast.warning("Please select your location on the map");
      return;
    }
  };

  return (
    <>
      <form onSubmit={handleSubmit(submit)} className={classes.container}>
        <div className={classes.content}>
          <Title title="Order Form" fontSize={24} />
          <div className={classes.inputs}>
            <Input
              defaultValue={user.name}
              label="Name"
              {...register("name")}
              error={errors.name}
            />
            <Input
              defaultValue={user.address}
              label="Address"
              {...register("address")}
              error={errors.address}
            />
          </div>
        </div>
        <div>
          <Title title="Choose Your Location" fontSize={24} />
        </div>

        <div className={classes.buttons_container}>
          <div className={classes.buttons}>
            <Button
              type="submit"
              text="Go To Payment"
              width="100%"
              height="3rem"
            />
          </div>
        </div>
      </form>
    </>
  );
}
