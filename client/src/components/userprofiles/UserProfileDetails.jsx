import { useContext, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getProfile, updateImage } from "../../managers/userProfileManager";
import { UserContext } from "../../App";
import { getPostsByUser } from "../../managers/postManager";

export default function UserProfileDetails()
{
  const [userProfile, setUserProfile] = useState();
  const [image, setImage] = useState()
  const currentUser = useContext(UserContext)
  const [usersPosts, setUsersPosts] = useState();

  const { id } = useParams();

  const fetchAndSetProfile = () =>
  {
    getProfile(id).then(setUserProfile);
  }

  useEffect(() =>
  {
    fetchAndSetProfile()
    getPostsByUser(id).then(setUsersPosts);

  }, [id]);

  if(!userProfile)
  {
    return null;
  }

  const onImageError = () =>
  {
    userProfile.imageLocation = "https://resources.alleghenycounty.us/css/images/Default_No_Image_Available.png"
  }

  const onUpdateImageClicked = () =>
  {
    updateImage(currentUser.id, image).then(fetchAndSetProfile)
  }

  return (
    <>
      <img src={`data:image/jpeg;base64,${userProfile.imageBlob}`} alt={userProfile.firstName} onError={onImageError} />
      {
        userProfile.id == currentUser.id
        && <div>
          <label htmlFor="img-input">profile image: </label>
          <input onChange={(e) => setImage(e.target.files[0])} type="file" id="img-input"></input>
          <div>
            <button onClick={onUpdateImageClicked}>update profile image</button>
          </div>
        </div>
      }
      <h3>{userProfile.fullName}</h3>
      <p>Username: {userProfile.userName}</p>
      <p>email: {userProfile.email}</p>
      <p>creation date: {new Date(userProfile.createDateTime).toDateString()}</p>
      <p>{userProfile.roles?.includes("Admin") ? "Admin" : "Author"}</p>

      <section>
        {usersPosts?.map((p) => (
          <div key={p.id} className="">
            <h2>{p.title}</h2>
            <img src={p.imageURL}></img>
            <p>{p.content}</p>
            <p>{p.publicationDate}</p>
            <p>{p.author?.firstName}</p>
          </div>
        ))}
      </section>
    </>
  );
}
