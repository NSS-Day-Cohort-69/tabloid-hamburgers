import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getProfile } from "../../managers/userProfileManager";

export default function UserProfileDetails()
{
  const [userProfile, setUserProfile] = useState();

  const { id } = useParams();

  useEffect(() =>
  {
    getProfile(id).then(setUserProfile);
  }, [id]);

  if(!userProfile)
  {
    return null;
  }

  const onImageError = () =>
  {
    userProfile.imageLocation = "https://resources.alleghenycounty.us/css/images/Default_No_Image_Available.png"
  }
  return (
    <>

      <img src={userProfile.imageLocation} alt={userProfile.firstName} onError={onImageError} />
      <h3>{userProfile.fullName}</h3>
      <p>Username: {userProfile.userName}</p>
      <p>email: {userProfile.email}</p>
      <p>creation date: {new Date(userProfile.createDateTime).toDateString()}</p>
      <p>{userProfile.roles?.includes("Admin") ? "Admin" : "Author"}</p>
    </>
  );
}
