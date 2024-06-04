import { useContext, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getProfile, updateImage } from "../../managers/userProfileManager";
import { UserContext } from "../../App";

export default function UserProfileDetails()
{
  const [userProfile, setUserProfile] = useState();
  const [image, setImage] = useState()
  const currentUser = useContext(UserContext)

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
      {
        userProfile.id == currentUser.id
        && <div>
          <label htmlFor="img-input">profile image: </label>
          <input onChange={(e) => setImage(e.target.files[0])} type="file" id="img-input"></input>
          <div>
            <button onClick={() => updateImage(currentUser.id, image)}>update profile image</button>
          </div>
        </div>
      }
      <h3>{userProfile.fullName}</h3>
      <p>Username: {userProfile.userName}</p>
      <p>email: {userProfile.email}</p>
      <p>creation date: {new Date(userProfile.createDateTime).toDateString()}</p>
      <p>{userProfile.roles?.includes("Admin") ? "Admin" : "Author"}</p>
    </>
  );
}
