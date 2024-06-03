import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getTagById, updateTagByTagObject } from "../../../managers/tags";

export const TagsEditView = () => {
  const [tag, setTag] = useState({});
  const { TagId } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    getTagById(TagId).then(setTag);
  }, []);

  const handleSave = (e) => {
    e.preventDefault();

    if (tag.tagName != "") {
      updateTagByTagObject(tag).then(() => {
        navigate(`/tags`);
      });
    }
  };

  return (
    <main>
      <div>
        <form onSubmit={handleSave}>
          <input
            required
            onChange={(evt) => {
              const copy = { ...tag };
              copy.tagName = evt.target.value;
              setTag(copy);
            }}
            defaultValue={tag.tagName}
          />
          <button
            onClick={() => {
              navigate(`/tags`);
            }}
          >
            Cancel
          </button>
          <button type="submit">Change</button>
        </form>
      </div>
    </main>
  );
};
