import { useState } from "react";
import ConfirmDialog from "../../../../shared/components/ConfirmDialog";
import { useDeleteClothingItem } from "../../../clothing/hooks/useDeleteClothingItem";
import { useLocation, useNavigate } from "react-router";

type Props = {
    itemId: string
}

const ItemActions = ({ itemId }: Props) => {
    const navigate = useNavigate();
    const location = useLocation();

    const [showDialog, setShowDialog] = useState<boolean>(false);
    const { deleteItem } = useDeleteClothingItem();

    return (
        <>
            <div className="flex flex-row w-full mb-4 gap-4">
                <button className="bg-black w-full text-white flex-3 py-2 px-4 rounded-lg">Edit</button>
                <button className="bg-red-100 w-full flex-1 py-2 px-4 rounded-lg text-red-400" onClick={() => setShowDialog(true)}>Delete</button>
            </div>     
            {showDialog && 
                <ConfirmDialog 
                    message="Are you sure you want to delete this item?" 
                    onConfirm={async () => {await deleteItem(itemId); navigate(location.state?.from ?? -1, { replace: true })}} 
                    onCancel={() => setShowDialog(false)}
                />
            } 
        </>
    );
};

export default ItemActions;